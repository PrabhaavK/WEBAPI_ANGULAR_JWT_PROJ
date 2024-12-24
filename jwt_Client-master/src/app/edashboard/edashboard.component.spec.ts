import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EdashboardComponent } from './edashboard.component';

describe('EdashboardComponent', () => {
  let component: EdashboardComponent;
  let fixture: ComponentFixture<EdashboardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EdashboardComponent]
    });
    fixture = TestBed.createComponent(EdashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
