import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '@app-core/abstractions';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-feature-profile',
  standalone: true,
  imports: [],
  templateUrl: './feature-profile.component.html',
  styles: ``,
})
export class FeatureProfileComponent extends BaseComponent implements OnInit {
  profileId: string | undefined;

  constructor(private activatedRoute: ActivatedRoute) {
    super();
  }
  ngOnInit() {
    this.profileId =
      this.activatedRoute.snapshot.paramMap.get('id') ?? undefined;
  }
}
