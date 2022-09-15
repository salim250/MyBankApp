import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoriqueTransfertComponent } from './historique-transfert.component';

describe('HistoriqueTransfertComponent', () => {
  let component: HistoriqueTransfertComponent;
  let fixture: ComponentFixture<HistoriqueTransfertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoriqueTransfertComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HistoriqueTransfertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
