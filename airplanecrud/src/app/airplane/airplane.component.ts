import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { airplaneService } from '../airplane.service';  
import { airplane } from '../airplane';  

@Component({
  selector: 'app-airplane',
  templateUrl: './airplane.component.html',
  styleUrls: ['./airplane.component.css']
})
export class airplaneComponent implements OnInit {

  dataSaved = false;  
  airplaneForm: any;  
  allairplanes: Observable<airplane[]>;  
  airplaneIdUpdate = null;  
  message = null;  

  constructor(private formbulider: FormBuilder, private airplaneService:airplaneService) { }

  ngOnInit() {
    this.airplaneForm = this.formbulider.group({  
      CodAviao: ['', [Validators.required]],  
      Movelo: ['', [Validators.required]],
      QtdePsg: [''],
      DataCriacao:['']
    });  
    this.loadAllairplanes();  
  }

  loadAllairplanes() {  
    this.allairplanes = this.airplaneService.getAllairplanes();  
  } 

  onFormSubmit() {  
    this.dataSaved = false;  
    const airplane = this.airplaneForm.value;  
    this.Createairplane(airplane);  
    this.airplaneForm.reset();  
  } 

  Createairplane(airplane: airplane) {  
    if (this.airplaneIdUpdate == null) {  
      this.airplaneService.createairplane(airplane).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.message = 'Registro salvo com sucesso';  
          this.loadAllairplanes();  
          this.airplaneIdUpdate = null;  
          this.airplaneForm.reset();  
        }  
      );  
    } else {  
      airplane.airplaneId = this.airplaneIdUpdate;  
      this.airplaneService.updateairplane(this.airplaneIdUpdate,airplane).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Registro atualizado com sucesso';  
        this.loadAllairplanes();  
        this.airplaneIdUpdate = null;  
        this.airplaneForm.reset();  
      });  
    }  
  }
  
  loadairplaneToEdit(airplaneid: string) {  
    this.airplaneService.getairplaneById(airplaneid).subscribe(airplane=> {  
      this.message = null;  
      this.dataSaved = false;  
      this.airplaneIdUpdate = airplane.airplaneId;  
      this.airplaneForm.controls['CodAviao'].setValue(airplane.CodAviao);  
      this.airplaneForm.controls['Modelo'].setValue(airplane.Modelo);
      this.airplaneForm.controls['QtdePsg'].setValue(airplane.QtdePsg);
      this.airplaneForm.controls['DataCriacao'].setValue(airplane.DataCriacao);
    });    
  }  

  deleteairplane(airplaneid: string) {  
    if (confirm("Deseja realmente deletar este airplane ?")) {   
      this.airplaneService.deleteairplaneById(airplaneid).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Registro deletado com sucesso';  
        this.loadAllairplanes();  
        this.airplaneIdUpdate = null;  
        this.airplaneForm.reset();  
      });  
    }  
  }  

  resetForm() {  
    this.airplaneForm.reset();  
    this.message = null;  
    this.dataSaved = false;  
  } 

}
