import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyComponent } from './my.component';
import { MyService } from '../Services/my.service';

describe('MyComponent', () => {
  let component: MyComponent;
  let fixture: ComponentFixture<MyComponent>;
  let dataService: MyService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyComponent ],
      providers: [ MyService ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyComponent);
    component = fixture.componentInstance;
    dataService = TestBed.inject(MyService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call saveData on form submission', () => {
    const formData = { a: 1, b: 5 };
    const addDataSpy = spyOn(dataService, 'divide').and.returnValue(5);

    component.submitForm(formData);

    expect(addDataSpy).toHaveBeenCalled();
  });

  it('should not call saveData when a = 0', () => {
    const formData = { a: 0, b: 5 };
    const addDataSpy = spyOn(dataService, 'divide').and.returnValue(5);

    component.submitForm(formData);

    expect(addDataSpy).not.toHaveBeenCalled();
  });
});
