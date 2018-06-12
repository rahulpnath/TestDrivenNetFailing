namespace Ploeh.Samples

open System

module Messaging =    
    type Envelope<'a> = {
        Id      : Guid
        Created : DateTimeOffset
        Item    : 'a }

    let envelop getId getTime item = {
        Id = Guid "1CF889F8-201F-44DF-BC86-77227651D3EE"
        Created = DateTimeOffset.MinValue
        Item = item }

module MessagingTests =
    open Xunit

    type Foo = { Text : string; Number : int }

    [<Fact>]
    let ``enevelope returns correct results`` () =
        let getId _ = Guid "1CF889F8-201F-44DF-BC86-77227651D3EE"
        let getTime _ = DateTimeOffset( 636322011751405346L, 
                                        TimeSpan.FromHours(-4.0) )
        let item = { Text = "Bar"; Number = 42 }

        let actual = Messaging.envelop getId getTime item

        Assert.Equal ( Guid "1CF889F8-201F-44DF-BC86-77227651D3EE",
                       actual.Id )
        Assert.Equal ( DateTimeOffset( 636322011751405346L, 
                                       TimeSpan.FromHours(-4.0) ),
                       actual.Created )
        Assert.Equal ( item, actual.Item ) 