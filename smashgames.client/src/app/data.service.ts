import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Studio } from './Models/meta';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  studio$: BehaviorSubject<Studio> = new BehaviorSubject<Studio>({});
  constructor(private http: HttpClient) { }

  // hook up our api to return the studio information and save back as the next value of this studio

}
