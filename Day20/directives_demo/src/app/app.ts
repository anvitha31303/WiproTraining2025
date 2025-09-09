import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule,FormsModule],
  template: `<h1>Hello {{ name }}</h1>
            <div *ngIf='showmessage'>
            <p>Welcome!</p>
            </div> 
            <table>
              <tr *ngFor='let f of data'>
                <td>{{f.name}}</td>
              </tr>
            </table>

            <h2>ngSwitch Example</h2>
            <div>
              @switch(status){
              @case('pending'){
              <p>Status: Pending</p>
              }
              @case('approved'){
              <p>Status: approved</p>
              }
              @case('rejected'){
              <p>Status: rejected</p>
              }
              @default{
              <p>Status: Unknown</p>
              }
              }
              </div>

              <p>Company Name: {{ companyName | uppercase }}</p>  
              <p>Purchase Date: {{ purchaseDate | date:'fullDate' }}</p>
              <p>Total Amount: {{ totalAmount | currency:'USD':'symbol':'1.2-2' }}</p>
              <p>Discount Rate: {{ discountRate | percent:'1.2-2' }}</p>
              <p>Note: {{ note | slice:0:30 }}...</p>   
              <p>Product ID: {{ productDetails.id }}</p>
              <p>Product Name: {{ productDetails.name }}</p>  
              <p>Product Specs: {{ productDetails.specs | json }}</p>

            `,
  styles: [`
    h1 {
      color: green;
    }
  `]
})
export class App {
  protected readonly title = signal('directives_demo');
  name : string ='Rajesh';
  showmessage = true;
  data = [
    { name: 'Rajesh' },
    { name: 'Suresh' },
    { name: 'Mahesh' }
  ];

  status = 'approved';

  companyName = 'acme technologies';
  purchaseDate = new Date(2025, 7, 9);
  totalAmount = 12345.678;
  discountRate = 0.15;
  note = 'This is a limited-time offer for premium customers only.';
  productDetails = { id: 101, name: 'Laptop', specs: { ram: '16GB', cpu: 'i7' } };
}