import { Component, OnInit } from '@angular/core';
import { HttpserviceService } from '../httpservice.service';
import { Product } from './enitiy.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  sector:Product;
  sectors:any;
  constructor(private sectorService:HttpserviceService) {
    console.log(this.sectors);
   }

   ngOnInit(): void {
    
    this.Reload();
    }
    View:any = [];
    Reload(){
     
      this.sectorService.getAllSectors().subscribe(data => {
        this.View = data;
        this.onReset();
      })
    }

    addData:Product={
      pid: 0,

      pname: '',

      pqty: 0,
      price: 0
    }
    Result:any=[];
    Edit(data:any){

      this.sectorService.ShowOne(data.pid).subscribe(res =>{
  
        this.Result=res;
  
        this.addData.pid=this.Result.pid;
  
        this.addData.pname=this.Result.pname;
  
        this.addData.pqty=this.Result.pqty;
        this.addData.price=this.Result.price;
  
      })
  
      
  
    }
    Submit(){

    
  
      this.sectorService.Add(this.addData).subscribe(res =>{
  
        alert('Data Submitted Successfully');
  
        this.Reload();
  
      })
  
    }
    Save(){
      if(this.addData.pname=="")
    {
      alert("Please enter Product name!");
    }
    else if(this.addData.price==0)
    {
      alert("Please enter Price!");
    }
    else if(this.addData.pqty==0)
    {
      alert("Please enter Quantity!");
    }
    else if(this.addData.pid==0)
    { 
      if(this.addData.pid==0){
        if (confirm("Are U Want To Submit!") == true)
        {
        this.Submit();
        this.Reload();
  
       }
       
    }
  }
    else{
      if (confirm("Are U Want To Update!") == true)
        {
        this.Update();
        this.Reload();
  
       }
    }
  
    
  
    

  
  
    
    }
    onReset(){
      this.addData.pname="";
  
        this.addData.pqty=0;
        this.addData.price=0;
    }
    Update(){
     
      this.sectorService.Add(this.addData).subscribe(res =>{
        alert('Data Update Successfully');
        this.addData.pid=0;
        this.Reload();
      })
    
  
    }
    Delete(data:any){
      if (confirm("Are U Want To Detete!") == true)
      {
        this.sectorService.Delete(data).subscribe(data =>{
  
          alert('Data Deleted Successfully');
    
          this.Reload();
    
        })
      }
      
  
    }
}
  
  
    
    


