//
//  ContentView.swift
//  Langium-ios
//
//  Created by alex on 30.05.2020.
//  Copyright © 2020 Langium Inc. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    var body: some View {
      /*TabView {
          Text("The First Tab")
              .tabItem {
                  Image("Search_icon")
              }
          Text("Another Tab")
              .tabItem {
                  Image("Dictionary_icon")
              }
          Text("The Last Tab")
              .tabItem {
                  Image("Training_icon")
              }
          Text("Another")
            .tabItem {
                Image("Profile_icon")
            }
      }
      .font(.headline)*/
        Text("")
    }
}

struct ContentView_Previews: PreviewProvider {
    @State private var selection = 0
    static var previews: some View {
        ContentView()
    }
}
