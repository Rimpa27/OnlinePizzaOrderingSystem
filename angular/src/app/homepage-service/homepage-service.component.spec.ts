import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomepageServiceComponent } from './homepage-service.component';

describe('HomepageServiceComponent', () => {
  let component: HomepageServiceComponent;
  let fixture: ComponentFixture<HomepageServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomepageServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomepageServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
