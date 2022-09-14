import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MAJDemandeComponent } from './majdemande.component';

describe('MAJDemandeComponent', () => {
  let component: MAJDemandeComponent;
  let fixture: ComponentFixture<MAJDemandeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MAJDemandeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MAJDemandeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
