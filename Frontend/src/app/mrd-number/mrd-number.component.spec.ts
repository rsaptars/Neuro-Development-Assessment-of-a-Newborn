import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MrdNumberComponent } from './mrd-number.component';

describe('MrdNumberComponent', () => {
  let component: MrdNumberComponent;
  let fixture: ComponentFixture<MrdNumberComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MrdNumberComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MrdNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
