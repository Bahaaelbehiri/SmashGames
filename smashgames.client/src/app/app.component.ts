import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Studio } from './Models/meta';
import { DataService } from './data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  studio: BehaviorSubject<Studio> = this.data.studio$;

  constructor(private http: HttpClient, private data:DataService) { }

  // hook up our api to studio information and save back as the next as the next value of this.studio

  ngOnInit() {
  
  }
  
  title = 'smashgames.client';
}
