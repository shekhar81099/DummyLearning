import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VillainsDetailComponent } from './villains-detail.component';

describe('VillainsDetailComponent', () => {
  let component: VillainsDetailComponent;
  let fixture: ComponentFixture<VillainsDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VillainsDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VillainsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
