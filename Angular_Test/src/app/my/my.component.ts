import { Component } from '@angular/core';
import { MyService } from '../Services/my.service';

@Component({
  selector: 'app-my',
  templateUrl: './my.component.html',
  styleUrls: ['./my.component.css']
})
export class MyComponent {
  constructor(private myService: MyService) { }

  submitForm(formData: any): void {
    if (formData.a > 0) {
      this.myService.divide(formData.a, formData.b);
    }    
  }
}
