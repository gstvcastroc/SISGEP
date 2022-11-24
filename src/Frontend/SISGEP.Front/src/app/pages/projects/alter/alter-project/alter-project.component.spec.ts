import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterProjectComponent } from './alter-project.component';

describe('AlterProjectComponent', () => {
  let component: AlterProjectComponent;
  let fixture: ComponentFixture<AlterProjectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlterProjectComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlterProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
