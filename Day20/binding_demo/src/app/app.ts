import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true, // ✅ tells Angular it's standalone
  imports: [ FormsModule], // ✅ add FormsModule here
  templateUrl: './app.html',
  styleUrls: ['./app.css'] // also fix styleUrl -> styleUrls
})
export class App {
  protected readonly title = signal('binding_demo');
  name: string = 'rajesh';
  age: number = 22;

  inputValue: string = 'Hello Angular!';

  title1 = "Property Binding Demo";
  classtype = "text-danger";
  company = "Wipro Technologies";

  // property binding
  btnHeight: string = '50px';
  btnWidth: string = '150px';
  btnLabel: string = 'Click Me';

  // event binding
  message: string = 'Hello!';

  addProduct() {
    this.message = 'You clicked the button!';
  }

  firstname: string = 'Rajesh';
}
