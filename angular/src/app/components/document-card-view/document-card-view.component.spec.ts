import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocumentCardViewComponent } from './document-card-view.component';

describe('DocumentCardViewComponent', () => {
  let component: DocumentCardViewComponent;
  let fixture: ComponentFixture<DocumentCardViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DocumentCardViewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DocumentCardViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
