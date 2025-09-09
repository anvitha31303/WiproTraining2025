import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Studentmarks } from './studentmarks';

describe('Studentmarks', () => {
  let component: Studentmarks;
  let fixture: ComponentFixture<Studentmarks>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Studentmarks]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Studentmarks);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
