import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IpbStructureComponent } from './ipb-structure.component';

describe('IpbStructureComponent', () => {
  let component: IpbStructureComponent;
  let fixture: ComponentFixture<IpbStructureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IpbStructureComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IpbStructureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
