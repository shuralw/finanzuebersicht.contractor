export enum AppEventType {
    Success,
    Error,
    Warning
}

export interface AppEvent {
    eventType: AppEventType;
    message: string;
    uniqueEventCode?: string;
}
