import { AuthService } from '@abp/ng.core';
import { Component, ViewChild } from '@angular/core';
import {
  ApexNonAxisChartSeries,
  ApexPlotOptions,
  ApexChart,
  ApexFill,
  ChartComponent,
  ApexStroke
} from "ng-apexcharts";
import { NavigationEnd, Router, RouterModule } from '@angular/router';

export type ChartOptions = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  labels: string[];
  plotOptions: ApexPlotOptions;
  fill: ApexFill;
  stroke: ApexStroke;
};


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;
  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated
  }

  constructor(private authService: AuthService,
    private router: Router) {
    this.chartOptions = {
      series: [10],
      chart: {
        events: {
          dataPointMouseEnter(e, chart, options) {
            return null;
          },
        },
        selection: {
          enabled: false,
        },
        height: 150,
        type: 'radialBar',
        toolbar: {
          show: false,
        },
      },
      plotOptions: {
        radialBar: {
          startAngle: -179,
          endAngle: 180,
          hollow: {
            margin: 0,
            size: '70%',
            background: '#fff',
            image: undefined,
            position: 'front',
            dropShadow: {
              enabled: true,
              top: 3,
              left: 0,
              blur: 4,
              opacity: 0.1,
            },
          },
          track: {
            background: '#fff',
            strokeWidth: '67%',
            margin: 0, // margin is in pixels
            dropShadow: {
              enabled: true,
              top: 0,
              left: 0,
              blur: 4,
              opacity: 0.1,
            },
          },

          dataLabels: {
            show: true,
            name: {
              offsetY: 15,
              color: '#111',
              fontSize: '36px',
              show: true,
            },
            value: {
              formatter: function (val) {
                return parseInt(val.toString(), 70).toString();
              },
              color: '#111',
              fontSize: '36px',
              show: false,
            },
          },
        },
      },
      fill: {
        type: 'radialBar',
        colors: ['var(--bs-success)'],
      },
      stroke: {
        lineCap: 'round',
      },
      labels: ['700%'],
    };
  }

  login() {
    this.authService.navigateToLogin();
  }


  RouteToCaliGen(){
    this.router.navigate(['/chat-screen']);
  }
}
