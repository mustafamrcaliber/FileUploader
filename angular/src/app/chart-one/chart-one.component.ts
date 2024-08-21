import { Component, OnInit } from '@angular/core';
import { ExtraAppServicesService } from '../proxy/file-uploader-saver';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';


@Component({
  selector: 'app-chart-one',
  templateUrl: './chart-one.component.html',
  styleUrl: './chart-one.component.scss'
})
export class ChartOneComponent implements OnInit {
  url: string = undefined;
  trustedUrl: SafeResourceUrl;
  constructor(
    private extraService: ExtraAppServicesService,
    private sanitizer: DomSanitizer
  )
  {
    this.extraService.getUrlForIFrame().subscribe(x => {
      console.log( x, "xxxxx")
      this.url = x;
      this.trustedUrl = this.sanitizer.bypassSecurityTrustResourceUrl(this.url);
    });

  }

  ngOnInit(): void {

  }
}
