import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgIf } from '@angular/common';
@Component({
  selector: 'app-root',
  imports: [NgIf],
  template : `
  <button (click)="doSomething()">Do Something</button>
  <div *ngIf="errorMessage" class="error-message">
    {{ errorMessage  }}
  </div>
  `,
  styles: ['.error-message { color: red; }'],
})
export class App {
  protected readonly title = signal('errorhandling');

errorMessage: string | null = null;

doSomething()
{
  try{
        const data=JSON.parse('{"name":"Alice"}');

        console.log(data);

        }
  catch(error:any){
    this.errorMessage = `An error occurred: ${error.message}`;

    console.error('Synchronous error is caught:', error);

  }
 

}
}

