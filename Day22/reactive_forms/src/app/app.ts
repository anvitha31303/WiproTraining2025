import { Component, NgModule, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import{ReactiveFormsModule} from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { UserForm } from './user-form/user-form';
@NgModule({
  //selector: 'app-root',
  declarations:[UserForm],
  imports: [BrowserModule,ReactiveFormsModule],
  //templateUrl: './app.html',
  //styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('reactive_forms');
}
