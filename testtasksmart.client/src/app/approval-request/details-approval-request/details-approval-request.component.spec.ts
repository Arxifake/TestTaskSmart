import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsApprovalRequestComponent } from './details-approval-request.component';

describe('DetailsApprovalRequestComponent', () => {
  let component: DetailsApprovalRequestComponent;
  let fixture: ComponentFixture<DetailsApprovalRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetailsApprovalRequestComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailsApprovalRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
