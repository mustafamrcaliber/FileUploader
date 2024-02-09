import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FileViewMastersComponent } from './file-view-masters.component';

describe('FileViewMastersComponent', () => {
  let component: FileViewMastersComponent;
  let fixture: ComponentFixture<FileViewMastersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FileViewMastersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FileViewMastersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
