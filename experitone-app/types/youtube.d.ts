interface Window {
    YT: typeof YT;
}

declare namespace YT {
    class Player {
        constructor(elementId: string | HTMLElement, options: any);
        playVideo(): void;
        pauseVideo(): void;
    }

    interface PlayerEvent {
        target: Player;
    }

    interface ErrorEvent {
        data: number;
    }
}
