import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'access', pathMatch: 'full' },
  { path: 'access',
     loadChildren : () =>
    import('./user-access/user-access.module').then((c)=>c.UserAccessModule)
  },
  { path: '**', redirectTo: 'access' }
];
@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
  })
  export class AppRoutingModule {}
  