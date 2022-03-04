import { Component, OnInit } from '@angular/core';
import { Observable, Subscription, interval } from 'rxjs';
import { NoteService } from './services/note.service';
import { SatelliteService } from './services/satellite.service'; 
import { Satellite } from './types/satellite.type';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit { 
  satelliteCoordinates!:Satellite;
  //public dataSource: MatTableDataSource<IRandomUsers>;
  displayedColumns: string[] = ['NoteId', 'latitude', 'longitude'];
  constructor(private _satelliteService: SatelliteService,
    private _noteService:NoteService) {

  }
  ngOnInit(): void {
    const source = interval(2000); 
    source.subscribe(val => this.getSatelliteInfo());

  //  dataSource = ELEMENT_DATA;
  } 

  private getSatelliteInfo() {
    this._satelliteService.getInfo().subscribe(res => {

      this.satelliteCoordinates= res.result;
      // console.log(this.satelliteCoordinates);
      // console.log(res);
    });

  }


}
