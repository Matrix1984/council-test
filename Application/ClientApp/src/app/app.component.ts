import { Component, OnInit } from '@angular/core';
import { Observable, Subscription, interval } from 'rxjs';
import { NoteService } from './services/note.service';
import { SatelliteService } from './services/satellite.service'; 
import { Note } from './types/note.type';
import { Satellite } from './types/satellite.type';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit { 
  initialDataLoaded:boolean=false;
  satelliteCoordinates!:Satellite;
  public dataSource!: MatTableDataSource<Note>;
  displayedColumns: string[] = ['NoteId', 'latitude', 'longitude'];
  constructor(private _satelliteService: SatelliteService,
    private _noteService:NoteService) {

  }
  ngOnInit(): void {
    const source = interval(2000); 
    source.subscribe(val => this.getSatelliteInfo());

   this._noteService.listNotes().subscribe((res)=>{
    //  console.log('notes request')
    //  console.log(res)
     this.dataSource = new MatTableDataSource<Note>(res);
     this.initialDataLoaded=true;
   })
  } 

  private getSatelliteInfo() {
    this._satelliteService.getInfo().subscribe(res => { 
      this.satelliteCoordinates= res.result; 
    }); 
  }


}
