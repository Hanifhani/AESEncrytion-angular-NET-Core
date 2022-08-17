import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {
    path:'',loadChildren:()=>import("./main/main.module").then(mod=>mod.MainModule),canActivate:[AuthGuard]
  },
  {
    path:'auth',loadChildren:()=>import("./auth/auth.module").then(mod=>mod.AuthModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
