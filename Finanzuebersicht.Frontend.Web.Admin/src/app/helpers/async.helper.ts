import { ReplaySubject } from 'rxjs';

export function fromReplaySubjectToPromise<T>(replaySubject: ReplaySubject<T>): Promise<T> {
    let resolved = false;
    return new Promise<T>((resolve, reject) => {
        const subscription = replaySubject.subscribe((data: T) => {
            resolve(data);
            subscription.unsubscribe();
            resolved = true;
        }, (error) => {
            reject(error);
            subscription.unsubscribe();
            resolved = true;
        }, () => {
            if (!resolved) {
                reject(null);
            }
        });
    });
}
