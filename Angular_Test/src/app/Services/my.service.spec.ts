import { TestBed } from '@angular/core/testing';

import { MyService } from './my.service';

describe('MyService', () => {
  let service: MyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return correct value from getValue()', () => {
    const value = service.getValue();
    expect(value).toEqual('some value');
  });

  it('should add two numbers correctly', () => {
    const result = service.add(5, 3);
    expect(result).toEqual(8);
  });

  it('should handle division by zero gracefully', () => {
    expect(() => { service.divide(10, 0) }).toThrowError('Cannot divide by zero');
  });
});
