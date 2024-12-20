import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartGridViewComponent } from './part-grid-view.component';

describe('PartGridViewComponent', () => {
  let component: PartGridViewComponent;
  let fixture: ComponentFixture<PartGridViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PartGridViewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PartGridViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
