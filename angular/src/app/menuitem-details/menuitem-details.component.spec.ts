import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuitemDetailsComponent } from './menuitem-details.component';

describe('MenuitemDetailsComponent', () => {
  let component: MenuitemDetailsComponent;
  let fixture: ComponentFixture<MenuitemDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MenuitemDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MenuitemDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
