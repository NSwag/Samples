import * as generated from "./services";

export class ClientBase {
    protected transformOptions(options: any) {
        console.log("HTTP call, options: " + JSON.stringify(options));

        options.headers.append("myheader", "myvalue"); 
        return Promise.resolve(options);
    }
}