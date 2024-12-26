import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartDetailsPageComponent } from './part-details-page.component';

describe('PartDetailsPageComponent', () => {
  let component: PartDetailsPageComponent;
  let fixture: ComponentFixture<PartDetailsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PartDetailsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PartDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
