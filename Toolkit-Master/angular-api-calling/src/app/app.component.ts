import { Component } from '@angular/core';
import { ApiCallService } from './api-call.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-api-calling';
  searchTxtVal:string='';
  showOutput: boolean=false;
  output:string='';
  isLoading: boolean=false;

  constructor(private service:ApiCallService){}

  getResult() {

    this.isLoading=true;
    this.output="";
    this.service.getData(this.searchTxtVal).subscribe(data=>
      {this.output=data as string;this.showOutput=true;this.isLoading = false;})
  }
}
