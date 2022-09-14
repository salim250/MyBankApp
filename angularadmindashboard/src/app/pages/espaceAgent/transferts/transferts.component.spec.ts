import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransfertsComponent } from './transferts.component';

describe('TransfertsComponent', () => {
  let component: TransfertsComponent;
  let fixture: ComponentFixture<TransfertsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransfertsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransfertsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
