import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkoutsLayoutComponent } from './workouts-layout.component';

describe('WorkoutsLayoutComponent', () => {
  let component: WorkoutsLayoutComponent;
  let fixture: ComponentFixture<WorkoutsLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkoutsLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkoutsLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
