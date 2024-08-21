import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutoDataVisualizationComponent } from './auto-data-visualization.component';

describe('AutoDataVisualizationComponent', () => {
  let component: AutoDataVisualizationComponent;
  let fixture: ComponentFixture<AutoDataVisualizationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AutoDataVisualizationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AutoDataVisualizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
