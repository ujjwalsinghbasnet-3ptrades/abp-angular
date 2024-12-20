import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartCardViewComponent } from './part-card-view.component';

describe('PartCardViewComponent', () => {
  let component: PartCardViewComponent;
  let fixture: ComponentFixture<PartCardViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PartCardViewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PartCardViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
