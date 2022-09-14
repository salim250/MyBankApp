import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExtraitComponent } from './extrait.component';

describe('ExtraitComponent', () => {
  let component: ExtraitComponent;
  let fixture: ComponentFixture<ExtraitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExtraitComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExtraitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
