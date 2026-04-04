import { provideZoneChangeDetection } from "@angular/core";
/// <reference types="@angular/localize" />

import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './components/app/app.component';
import { appConfig } from './components/app/app.config';

bootstrapApplication(AppComponent, {...appConfig, providers: [provideZoneChangeDetection(), ...appConfig.providers]})
   .catch(err => console.error(err));
