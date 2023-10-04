import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import {FormsModule} from "@angular/forms";
import {SharedModule} from "../shared/shared.module";



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent
  ],
  exports: [
    ShopComponent
  ],
    imports: [
        CommonModule,
        FormsModule,
        SharedModule
    ]
})
export class ShopModule { }
