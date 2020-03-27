
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CommonModule } from '@angular/common';
import { GenderPipe } from './pipes/gender.pipe';
import { AvatarSelectComponent } from './components/avatar-select/avatar-select.component';
import { MenuTypePipe } from './pipes/menu-type.pipe';
import { CanOperateDirective } from './directives/can-operate.directive';
import { DbTypePipe } from './pipes/db-type.pipe';

@NgModule({
  declarations: [
    GenderPipe,
    MenuTypePipe,
    DbTypePipe,
    AvatarSelectComponent,
    CanOperateDirective
  ],
  imports: [
    CommonModule,
    NgZorroAntdModule,
  ],
  exports: [
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    NgZorroAntdModule,
    GenderPipe,
    MenuTypePipe,
    DbTypePipe,
    AvatarSelectComponent,
    CanOperateDirective
  ]
})
export class AppCommonModule { }
