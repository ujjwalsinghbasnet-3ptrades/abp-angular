import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WindowsDialogComponent } from './windows-dialog.component';

describe('WindowsDialoggComponent', () => {
  let component: WindowsDialogComponent;
  let fixture: ComponentFixture<WindowsDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WindowsDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WindowsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
