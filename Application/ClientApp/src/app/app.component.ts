import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable, Subscription, interval } from 'rxjs';
import { NoteService } from './services/note.service';
import { SatelliteService } from './services/satellite.service'; 
import { Note } from './types/note.type';
import { Satellite } from './types/satellite.type';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder } from '@angular/forms'; 

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit { 
  initialDataLoaded:boolean=false;
  satelliteCoordinates!:Satellite;
  public dataSource!: MatTableDataSource<Note>;
  displayedColumns: string[] = ['NoteId', 'latitude', 'longitude'];
  @ViewChild('noteTable') matTable: any;

 form = this._formBuilder.group({
    note:['']
 });

  constructor(private _satelliteService: SatelliteService,
    private _noteService:NoteService,
    private  _formBuilder: FormBuilder) {

  }
  ngOnInit(): void {
    const source = interval(2000); 
    source.subscribe(val => this.getSatelliteInfo());

   this._noteService.listNotes().subscribe((res)=>{ 
     this.dataSource = new MatTableDataSource<Note>(res);
     this.initialDataLoaded=true;
   })
  } 

  private getSatelliteInfo() {
    this._satelliteService.getInfo().subscribe(res => { 
      this.satelliteCoordinates = res.result; 
    }); 
  }

  onFormSubmit(){
    console.log(this.form.get('note')?.value) 
    this._noteService.saveNote({
      latitude:this.satelliteCoordinates.iss_position.latitude,
      longitude:this.satelliteCoordinates.iss_position.longitude,
      Note:this.form.get('note')?.value
    }).subscribe((res)=>{ 
      this.dataSource.data.push(res);
      this.matTable.renderRows();
    });
  }

} 
