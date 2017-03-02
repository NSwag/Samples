import { Component } from '@angular/core';

import { SampleDataClient } from '../../services';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private client: SampleDataClient) {
        this.client.weatherForecasts().subscribe(forecasts => {
            console.log("Forecasts could be loaded via generated clients.");
        });
    }
}
