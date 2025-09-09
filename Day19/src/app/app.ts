import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h1>Wipro Student Dashboard</h1>
    <button (click)="toggleFees()">
      {{ showFees ? 'Hide Fees' : 'Show Fees' }}
    </button>

    <ul>
      <li *ngFor="let student of students">
        <strong>{{ student.name }}</strong>({{ student.gender }})<br>
        DOB: {{ student.dob | date:'MMMM d, y' }}<br>
        <span *ngIf="showFees"
              [ngStyle]="{ color: student.fee >= 9000 ? 'green' : 'red' }">
          Fee: {{ student.fee | currency:'INR':'symbol':'1.2-2' }}
        </span>
      </li>
    </ul>
  `,
  styles: [`
    h1 {
      font-family: Arial, sans-serif;
      font-weight: bold;
    }
    button {
      margin-bottom: 10px;
      padding: 5px 10px;
      font-size: 14px;
    }
    ul {
      font-size: 16px;
    }
  `]
})
export class App {
  showFees = true;

  students = [
    { name: 'Rakesh', gender: 'male', dob: new Date(1988, 11, 8), fee: 1234.56 },
    { name: 'Anurag', gender: 'male', dob: new Date(1989, 9, 14), fee: 6666.00 },
    { name: 'Priyanka', gender: 'female', dob: new Date(1992, 6, 24), fee: 6543.15 },
    { name: 'Akash', gender: 'female', dob: new Date(1990, 7, 19), fee: 9000.50 }
  ];

  toggleFees() {
    this.showFees = !this.showFees;
  }
}