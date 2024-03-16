import { Component, OnInit } from '@angular/core';
import { NzSpinComponent } from 'ng-zorro-antd/spin';
import { BaseComponent } from '@app-core/abstractions';
import { CommonService } from '@app-shared/services';
import { takeUntil } from 'rxjs';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-spinner-overlay',
  standalone: true,
  imports: [NzSpinComponent, NgIf],
  templateUrl: './spinner-overlay.component.html',
  styles: ``,
})
export class SpinnerOverlayComponent extends BaseComponent implements OnInit {
  progress = false;

  constructor(private commonService: CommonService) {
    super();
  }

  ngOnInit() {
    this.commonService.spinnerSubject$
      .pipe(takeUntil(this.destroy$))
      .subscribe((val) => (this.progress = val));
  }
}
