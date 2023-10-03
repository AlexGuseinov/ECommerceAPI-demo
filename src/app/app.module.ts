import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UiModule } from './ui/ui.module';

@NgModule({
  declarations: [AppComponent],
  providers: [],
  bootstrap: [
    AppComponent],
  imports: [
    BrowserModule,
     AppRoutingModule,
      UiModule
    ],
})
export class AppModule {}
