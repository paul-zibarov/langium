//
//  LoginPage.swift
//  Langium-ios
//
//  Created by alex on 04.06.2020.
//  Copyright © 2020 Langium Inc. All rights reserved.
//

import SwiftUI

struct LoginPage: View {
    var body: some View {
        VStack {
            ZStack {
                ZStack {
                    RoundedRectangle(cornerRadius: 15)
                    .fill(Color(#colorLiteral(red: 1, green: 1, blue: 1, alpha: 1)))
                }
                .compositingGroup()
                .frame(width: 282, height: 43.4)
                .shadow(color: Color(#colorLiteral(red: 0, green: 0, blue: 0, alpha: 0.25)), radius:4, x:0, y:0)
                
                TextField("Логін", text: /*@START_MENU_TOKEN@*//*@PLACEHOLDER=Value@*/.constant("")/*@END_MENU_TOKEN@*/)
                    .padding(.leading, 20.0)
                    .frame(width: 260.0, height: 40.0)
            }
            
            ZStack {
                ZStack {
                    RoundedRectangle(cornerRadius: 15)
                    .fill(Color(#colorLiteral(red: 1, green: 1, blue: 1, alpha: 1)))
                }
                    
                .compositingGroup()
                .frame(width: 282, height: 43.4)
                .shadow(color: Color(#colorLiteral(red: 0, green: 0, blue: 0, alpha: 0.25)), radius:4, x:0, y:0)
                
                TextField("Пароль", text: /*@START_MENU_TOKEN@*//*@PLACEHOLDER=Value@*/.constant("")/*@END_MENU_TOKEN@*/)
                    .padding(.leading, 20.0)
                    .frame(width: 260.0, height: 40.0)
                
            }
            .padding(.top)
            ZStack{
              ZStack {
                  RoundedRectangle(cornerRadius: 15)
                  .fill(Color(#colorLiteral(red: 0.6666666865348816, green: 0.8627451062202454, blue: 0.11764705926179886, alpha: 1)))
              }
                
              .compositingGroup()
              .frame(width: 195, height: 38.1)
              .shadow(color: Color(#colorLiteral(red: 0, green: 0, blue: 0, alpha: 0.25)), radius:4, x:0, y:0)
                
            Button(action: /*@START_MENU_TOKEN@*/{}/*@END_MENU_TOKEN@*/) {
                Text("Зареєструватися")
                    .fontWeight(.semibold)
                    .foregroundColor(Color.white)
                    .multilineTextAlignment(.center)
                    .padding(.vertical, 0.0)
                }
            }
            .padding(.top, 35.0)
            ZStack{
              ZStack {
                  RoundedRectangle(cornerRadius: 15)
                  .fill(Color(#colorLiteral(red: 0.6666666865348816, green: 0.8627451062202454, blue: 0.11764705926179886, alpha: 1)))
              }
                
              .compositingGroup()
              .frame(width: 94.8, height: 38.1)
              .shadow(color: Color(#colorLiteral(red: 0, green: 0, blue: 0, alpha: 0.25)), radius:4, x:0, y:0)
                
            Button(action: /*@START_MENU_TOKEN@*/{}/*@END_MENU_TOKEN@*/) {
                Text("Увійти")
                    .fontWeight(.semibold)
                    .foregroundColor(Color.white)
                    .multilineTextAlignment(.center)
                    .padding(.vertical, 0.0)
                }
            }
            .padding(.top, 15.0)
            
        }.background(
            Image("Mask Group"))
        
    }
}

struct LoginPage_Previews: PreviewProvider {
    static var previews: some View {
        LoginPage()
    }
}

