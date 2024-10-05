import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubServicesDetailesComponent } from './sub-services-detailes.component';

describe('SubServicesDetailesComponent', () => {
  let component: SubServicesDetailesComponent;
  let fixture: ComponentFixture<SubServicesDetailesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SubServicesDetailesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubServicesDetailesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
