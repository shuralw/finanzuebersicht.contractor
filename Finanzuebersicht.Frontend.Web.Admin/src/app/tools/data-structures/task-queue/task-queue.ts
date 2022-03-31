import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';

type ValidationTask = () => Promise<boolean>;
type Task = () => Promise<void>;

export interface TaskQueueItem {
    id: string;
    validate?: ValidationTask;
    task: Task;
}

export class TaskQueue {

    private taskQueue: TaskQueueItem[] = [];

    private lengthReplaySubject = new ReplaySubject<number>(1);

    public async validate(): Promise<boolean> {
        const validations = this.taskQueue
            .filter(taskQueueItem => taskQueueItem.validate != null)
            .map(taskQueueItem => taskQueueItem.validate());
        const validationResults = await Promise.all(validations);

        return !validationResults.some(validationResult => !validationResult);
    }

    public async execute(): Promise<void> {
        const tasks = this.taskQueue.map(taskQueueItem => taskQueueItem.task());
        await Promise.all(tasks);
    }

    public async executeNonParallel(): Promise<void> {
        let firstError = null;
        for (const taskQueueItem of this.taskQueue) {
            try {
                await taskQueueItem.task();
            } catch (e) {
                if (firstError === null) {
                    firstError = e;
                }
            }
        }

        if (firstError) {
            throw firstError;
        }
    }

    public registerTask(taskQueueItem: TaskQueueItem): void {
        const index = this.taskQueue.findIndex((item) => item.id === taskQueueItem.id);
        if (index >= 0) {
            this.taskQueue[index] = taskQueueItem;
        } else {
            this.taskQueue.push(taskQueueItem);
            this.lengthReplaySubject.next(this.taskQueue.length);
        }
    }

    public reset(): void {
        this.taskQueue = [];
        this.lengthReplaySubject.next(this.taskQueue.length);
    }

    public length(): number {
        return this.taskQueue.length;
    }

    public length$(): Observable<number> {
        return this.lengthReplaySubject.asObservable();
    }

    public isEmpty(): boolean {
        return this.length() === 0;
    }

    public isEmpty$(): Observable<boolean> {
        return this.length$()
            .pipe(map(length => length === 0));
    }

}
