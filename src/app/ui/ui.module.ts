import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from './layout/layout.module';
import { LoginsModule } from './logins/logins.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    LayoutModule,
    LoginsModule
  ],
  exports:[
    LayoutModule,
    LoginsModule
  ]
})
export class UiModule { }
